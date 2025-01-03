using App.Domain.Core.CardToCard.Card.Entity;
using App.Domain.Core.CardToCard.User.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Db.SqlServer.Ef.Db
{
    public static class OnlineUser
    {
        public static string? Online { get; set; }
        public static Card OnlineCard { get; set; }
        public static User User { get; set; }
        public static string Code { get; set; }
        public static float Amount { get; set; }
        public static string DesteniCard { get; set; }
    }
}
