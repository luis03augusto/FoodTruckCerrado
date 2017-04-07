using FoodTruckCerrado.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using WebMatrix.WebData;

namespace FoodTruckCerrado.DAO
{
    public class ProprietarioDao
    {
        public IList<Proprietario> ListaTodos()
        {
            using (var contexto = new Contexto())
            {
                return contexto.Proprietarios.ToList();
            }
        }

        public void DeletaUser(string email)
        {
            ((SimpleMembershipProvider)Membership.Provider).DeleteAccount(email);
            ((SimpleMembershipProvider)Membership.Provider).DeleteUser(email, true);



        }
    }
}