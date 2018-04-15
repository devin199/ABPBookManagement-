using Abp.Web.Mvc.Views;

namespace Book.Web.Views
{
    public abstract class BookWebViewPageBase : BookWebViewPageBase<dynamic>
    {

    }

    public abstract class BookWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected BookWebViewPageBase()
        {
            LocalizationSourceName = BookConsts.LocalizationSourceName;
        }
    }
}