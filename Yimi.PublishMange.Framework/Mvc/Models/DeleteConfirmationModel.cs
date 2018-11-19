
namespace Yimi.PublishManage.Framework.Mvc.Models
{
    public class DeleteConfirmationModel : BaseYimiEntityModel
    {
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string WindowId { get; set; }
    }
}