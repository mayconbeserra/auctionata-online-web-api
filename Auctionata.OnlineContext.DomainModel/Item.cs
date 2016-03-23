using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auctionata.OnlineContext.DomainModel
{
    public class Item
    {
        #region Constructors

        protected Item()
        {
        }

        public Item(string name, string description, string picturePath, double initialPrice)
        {
            this.Name = name;
            this.Description = description;
            this.PicturePath = picturePath;
            this.InitialPrice = initialPrice;
        }

        #endregion

        #region Properties

        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public string PicturePath { get; protected set; }
        public double InitialPrice { get; protected set; }

        #endregion
    }
}