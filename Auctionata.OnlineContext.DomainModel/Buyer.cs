using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auctionata.OnlineContext.DomainModel
{
    public class Buyer
    {
        #region Constructors

        protected Buyer()
        {
        }

        public Buyer(string name)
        {
            this.Name = name;
        }

        public Buyer(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        #endregion

        #region Properties

        public int Id { get; protected set; }
        public string Name { get; protected set; }

        #endregion
    }
}
