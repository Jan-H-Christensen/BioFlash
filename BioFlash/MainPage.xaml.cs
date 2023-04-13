using Plugin.Fingerprint.Abstractions;

namespace BioFlash;

public partial class MainPage : ContentPage
{
    private readonly IFingerprint fingerprint;
    public bool FlashlightSwitch { get; set; }
    public MainPage(IFingerprint fingerprint)
	{
		InitializeComponent();
        this.fingerprint = fingerprint;
	    FlashlightSwitch = true;
    }


    private async void OnCounterClicked(object sender, EventArgs e)
    {
        var request = new AuthenticationRequestConfiguration("Prove you have fingers!", "Because without it you can't have access");
        var result = await fingerprint.AuthenticateAsync(request);
        if (result.Authenticated)
        {
            await DisplayAlert("Authenticated!", "Access granted", "Cool beans");
            FlashlightSwitch_Toggled();

        }
        else
        {
            await DisplayAlert("Not authenticated!", "Access denied", "aww");
        }
        
    }

    private async void FlashlightSwitch_Toggled()
    {
        try
        {
            if (FlashlightSwitch)
            {
                await Flashlight.Default.TurnOnAsync();
                FlashlightSwitch = false;
            }
            else
            {
                await Flashlight.Default.TurnOffAsync();
                FlashlightSwitch = true;
            }
        }
        catch (FeatureNotSupportedException ex)
        {
            // Handle not supported on device exception
        }
        catch (PermissionException ex)
        {
            // Handle permission exception
        }
        catch (Exception ex)
        {
            // Unable to turn on/off flashlight
        }
    }
}

