using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
namespace fournisseur
{
    /// <summary>
    /// Description résumée de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Bonjour tout le monde";
        }

        [WebMethod]
        public string getTitreById(int id)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=librairie;User ID=sa;Password=P@ssw0rd");
            cn.Open();
            SqlCommand cmd = new SqlCommand("select nomouvr from ouvrage where numouvr = " + id, cn);

            SqlDataReader dr = cmd.ExecuteReader();
            string titre = "introuvable";
            if (dr.Read())
                titre = dr["nomouvr"].ToString();

            dr.Close();
            dr = null;
            cmd = null;
            cn.Close();
            cn = null;

            return titre;
        }



        [WebMethod]
        public string getInscriptionByVolontaire(int id)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=volontaires;User ID=sa;Password=P@ssw0rd");
            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from demande_inscription where id_volontaire = " + id, cn);

            SqlDataReader dr = cmd.ExecuteReader();
              string c = "<table><tr><th>Date demande </th><th>Stage </th><th>Etat </th> </tr>";

               while(dr.Read())
               {

                   c += "<tr><td>" + dr["date_demande"].ToString() + "</td> <td > " + dr["id_stage"].ToString() + " </ td><td>" + dr["etat"].ToString() + "</td></tr>";


               }
               c += "</table>";
      

            dr.Close();
           dr = null;
            cmd = null;
            cn.Close();
            cn = null;

            return c;
        }

    }
}
