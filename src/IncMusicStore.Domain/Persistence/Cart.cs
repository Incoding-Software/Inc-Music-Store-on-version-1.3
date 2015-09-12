namespace IncMusicStore.Domain
{
    #region << Using >>

    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using Incoding.Data;
    using Incoding.Quality;
    using JetBrains.Annotations;

    #endregion

    public class Basket : EntityBase
    {
        #region Fields

        readonly IList<Item> items = new List<Item>();

        #endregion

        #region Properties

        public virtual User User { get; protected set; }

        public virtual ReadOnlyCollection<Item> Items
        {
            get { return new ReadOnlyCollection<Item>(this.items); }
        }

        #endregion

        #region Api Methods

        public virtual void AddItem(Item item)
        {
            item.Basket = this;
            this.items.Add(item);
        }

        #endregion

        #region Nested classes

        [UsedImplicitly, Obsolete(ObsoleteMessage.ClassNotForDirectUsage, true), ExcludeFromCodeCoverage]
        public class Map : IncMusicStoreMap<Basket>
        {
            ////ncrunch: no coverage start
            #region Constructors

            public Map()
            {
                References(r => r.User).Cascade.SaveUpdate();
                HasMany(r => r.Items).Access.CamelCaseField().Cascade.AllDeleteOrphan();
            }

            #endregion

            ////ncrunch: no coverage end
        }

        #endregion
    }
}