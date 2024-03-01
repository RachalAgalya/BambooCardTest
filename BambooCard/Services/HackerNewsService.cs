using AutoMapper;
using BambooCard.Models;
using Newtonsoft.Json;

namespace BambooCard.Services
{
    public class HackerNewsService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public HackerNewsService(IMapper mapper, IConfiguration config)
        {
            _httpClient = new HttpClient();
            _mapper = mapper;
            _config = config;
        }

        public async Task<List<StoryDetailModel>?> GetBestStories(int n)
        {
            // Beststories external API URL to get n stories
            string bestStoriesUrl = _config.GetValue<string>("HackerNewsAPI:BestStories");
            try { 
                HttpResponseMessage response = await _httpClient.GetAsync(bestStoriesUrl);
                if (response.IsSuccessStatusCode)
                {
                    List<int>? BestStories = JsonConvert.DeserializeObject<List<int>>(response.Content.ReadAsStringAsync().Result);

                    if (BestStories != null)
                    {
                        List<StoryDetailModel>? details = await GetDetails(BestStories.Take(n).ToList());
                    
                        return details;
                    }
                    return null;
                }                
                return null;                
            }
            catch (Exception)
            {
                //Handle the exception here based on the requirement ex
                return null;
            }            
        }

        private async Task<List<StoryDetailModel>?> GetDetails(List<int> ids)
        {
            // Beststories details external API URL to get n stories
            string storyDetailsUrl = _config.GetValue<string>("HackerNewsAPI:StoryDetail");
            string extn = _config.GetValue<string>("HackerNewsAPI:Extn");
            List<StoryDetailModel> storyDetails = new();

            try
            {
                var task = Parallel.ForEachAsync(ids, new ParallelOptions() { MaxDegreeOfParallelism = 10 }, async (i, token) =>
                {
                    string url = String.Concat(storyDetailsUrl, i, extn);
                    HttpResponseMessage details = await _httpClient.GetAsync(url, token);
                    if (details.IsSuccessStatusCode)
                    {
                        string det = await details.Content.ReadAsStringAsync(token);
                        StoryModel? st = JsonConvert.DeserializeObject<StoryModel>(det);
                        StoryDetailModel storyDetailModel = _mapper.Map<StoryDetailModel>(st);
                        lock (storyDetails)
                        {
                            storyDetails.Add(storyDetailModel);
                        }
                    }
                });
                await task;

                storyDetails = storyDetails.OrderByDescending(s => s.Score).ToList();
                return (storyDetails);
            }
            catch (Exception)
            {
                //Handle the exception here based on the requirement ex
                return null;
            }
            
        }

    }
}
