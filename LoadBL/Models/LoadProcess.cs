﻿using System.Collections.Generic;
using System.Linq;
using LoadBL.Interfaces;

namespace LoadBL.Models
{
    public class LoadProcess : ILoadProcess
    {
        private static readonly IDictionary<int, LoadDto> Loads = new Dictionary<int, LoadDto>();
        public IList<LoadDto> GetList()
        {
            return new List<LoadDto>(Loads.Values); 
        }

        public LoadDto Get(int id)
        {
            return Loads.ContainsKey(id) ? Loads[id] : null;
        }

        public void Add(LoadDto load)
        {
            int max = Loads.Keys.Count == 0 ? 1 : Loads.Keys.Max(p => p) + 1;
            load.Id = max;
            Loads.Add(max, load);
        }

        public void Update(LoadDto load)
        {
            if (Loads.ContainsKey(load.Id))
                Loads[load.Id] = load;
        }

        public void Delete(int id)
        {
            if (Loads.ContainsKey(id))
                Loads.Remove(id);
        }
    }
}
