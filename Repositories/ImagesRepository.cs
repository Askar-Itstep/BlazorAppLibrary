
using BlazorAppLibrary.Models;

namespace BlazorAppLibrary.Repositories
{
    public class ImagesRepository : Repository<Image>
    {
        public ImagesRepository(myDBContext myDB) : base(myDB)
        {

        }
    }
}