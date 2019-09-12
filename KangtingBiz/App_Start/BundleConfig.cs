using System.Web;
using System.Web.Optimization;

namespace KangtingBiz
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(                      
                      "~/Content/*.css"));
        }
    }
}
