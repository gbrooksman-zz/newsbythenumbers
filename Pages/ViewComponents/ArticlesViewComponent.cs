using Microsoft.AspNetCore.Mvc;
using newsbythenumbers.Managers;
using System.Threading.Tasks;

namespace newsbythenumbers.ViewComponents
{
    public class ArticlesViewComponent : ViewComponent
    {
        private IArticleManager articleMgr;

        public ArticlesViewComponent(IArticleManager _articleMgr)
        {
            articleMgr = _articleMgr;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var article = await articleMgr.GetOne(System.Guid.NewGuid());
            return View(article);
        }
    }
}