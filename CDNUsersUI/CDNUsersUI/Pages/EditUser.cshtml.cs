using CDNUsersAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CDNUsersUI.Pages
{
    public class EditUserModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public EditUserModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [BindProperty]
        public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var client = _clientFactory.CreateClient("apiClient");
            User = await client.GetFromJsonAsync<User>($"api/Users/{id}");

            if (User == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var client = _clientFactory.CreateClient("apiClient");

            var response = await client.PutAsJsonAsync($"api/Users/{User.Id}", User);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}