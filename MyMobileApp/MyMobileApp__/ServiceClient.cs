using System.Linq;

namespace MyMobileApp
{
    public class ServiceClient
    {
        public int[] GetDataPoints()
        {
            return Enumerable.Range(0, 20).ToArray();
        }
    }
}
