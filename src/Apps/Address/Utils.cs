using FirstAPI.Data;

namespace FirstAPI.Utils;

public class AddressesUtilities
{
    public static bool CheckIfAddressExists(MovieAppContext context, int id)
    {
        var cinemaFromDb = context.Cinemas.FirstOrDefault(cinema => cinema.ID == id);
        return cinemaFromDb != null;
    }
}
