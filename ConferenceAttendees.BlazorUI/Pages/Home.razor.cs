using ConferenceAttendees.BlazorUI.Services.Base;
using Microsoft.AspNetCore.Components;

namespace ConferenceAttendees.BlazorUI.Pages
{
    public partial class Home
    {
        [Inject] NavigationManager _navManager { get; set; }
        [Inject] IClient _client { get; set; }
        Attendee Attendee { get; set; } = new();
        List<Gender> genders { get; set; } = [];
        List<ReferralSource> referralSources { get; set; } = [];
        List<JobRole> jobRoles { get; set; } = [];

        protected override async Task OnInitializedAsync()
        {
            genders = (await _client.GendersAllAsync()).ToList();
            referralSources = (await _client.ReferralSourcesAllAsync()).ToList();
            jobRoles = (await _client.JobRolesAllAsync()).ToList();
        }

        private async Task HandleValidSubmit()
        {
            // Perform form submission here\
            try
            {
                await _client.AttendeesPOSTAsync(Attendee);
            }
            catch (Exception)
            {

            }
            
            _navManager.NavigateTo("/success");
        }
    }
}