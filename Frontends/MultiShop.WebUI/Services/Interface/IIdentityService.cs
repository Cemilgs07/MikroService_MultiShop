using MultiShop.DtoLayer.IdentityDtos;

namespace MultiShop.WebUI.Services.Interface
{
	public interface IIdentityService
	{
		Task<bool> SignIn(SignInDto signUpDto);
	}
}
