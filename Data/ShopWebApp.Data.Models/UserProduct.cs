using ShopWebApp.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopWebApp.Data.Models
{
    public class UserProduct : BaseDeletableModel<int>
    {
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
