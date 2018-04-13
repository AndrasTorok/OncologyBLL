using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oncology.Model
{
    public class CollectionChangeDetector<T>
        where T : class, IIdentity
    {
        public static CollectionChanges<T> CollectionChanges(IEnumerable<T> liveEntities, IEnumerable<T> storeEntities)
        {
            List<T> addedEntities = liveEntities.Where(live => live.Id == 0).ToList();
            List<T> removedEntities = storeEntities.Where(store => !liveEntities.Select(live => live.Id).Contains(store.Id)).ToList();
            List<T> updatedEntities = (from live in liveEntities
                                       join store in storeEntities on live.Id equals store.Id
                                       where !live.Equals(store)
                                       select live).ToList();

            CollectionChanges<T> collectionChanges = new CollectionChanges<T>
            {
                Added = addedEntities,
                Deleted = removedEntities,
                Updated = updatedEntities
            };

            return collectionChanges;
        }
    }

    public class CollectionChanges<T>
    {
        public List<T> Added { get; set; }
        public List<T> Updated { get; set; }
        public List<T> Deleted { get; set; }
    }
}
