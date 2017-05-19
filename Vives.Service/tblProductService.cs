using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vives.DAO;
using Vives.Models;
namespace Vives.Service
{
   public class tblProductService
    {
        private tblProductDAO productDAO = new tblProductDAO();
        private tblTreinplaatsDAO treinplaatsDAO = new tblTreinplaatsDAO();
        //kijken als het een hotel is
        public bool isHotel(tblProduct product)
        {
            return productDAO.isHotel(product);
        }
        //prijs opvragen
        public double getPrijs(tblProduct product)
        {
           
                if (productDAO.getProduct(product.ProductID) != null)//bestaat product
                {
                    return productDAO.getPrijs(product);
                }
                else
                {
                    throw new Exception("Product bestaat niet");
                }
            

        }
        //zoek product op ID
        public tblProduct getProduct(int ID)
        {
            return productDAO.getProduct(ID);
        }
        //zoek product op hotelID
        public tblProduct getProductByHotel(int hotelID)
        {
            return productDAO.getProductByHotel(hotelID);
        }
        //zoek product op TrajectID
        public tblProduct getProductByTraject(int trajectID, bool isBusinessklasse)
        {
            return productDAO.getProductByTraject(trajectID, isBusinessklasse);
        }
    }
}
