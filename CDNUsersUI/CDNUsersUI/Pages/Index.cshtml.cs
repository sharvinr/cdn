using CDNUsersAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CDNUsersUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public IndexModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public List<User> Users { get; set; }

        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Mail { get; set; }
        [BindProperty]
        public string PhoneNumber { get; set; }
        [BindProperty]
        public string Skillsets { get; set; }
        [BindProperty]
        public string Hobby { get; set; }

        public async Task OnGetAsync()
        {
            var client = _clientFactory.CreateClient("apiClient");
            Users = await client.GetFromJsonAsync<List<User>>("api/Users");
        }

        public async Task<IActionResult> OnPostRegisterUserAsync()
        {
            var newUser = new User
            {
                Username = Username,
                Mail = Mail,
                PhoneNumber = PhoneNumber,
                Skillsets = Skillsets != null ? Skillsets.Split(',').Select(s => s.Trim()).ToList() : new List<string>(),
                Hobby = Hobby != null ? Hobby.Split(',').Select(h => h.Trim()).ToList() : new List<string>()
            };

            var client = _clientFactory.CreateClient("apiClient");
            var response = await client.PostAsJsonAsync("api/Users", newUser);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteUserAsync(int id)
        {
            var client = _clientFactory.CreateClient("apiClient");
            var response = await client.DeleteAsync($"api/Users/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage();
            }

            return Page();
        }
    }
}
