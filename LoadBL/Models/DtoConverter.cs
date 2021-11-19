using System.Collections.Generic;
using LoadBL.Entities;

namespace LoadBL.Models
{
    public class DtoConverter
    {
        public static LoadDto Convert(Load load)
        {
            if (load == null)
                return null;
            LoadDto loadDto = new LoadDto();
            loadDto.Id = load.LoadId;
            loadDto.Teacher = load.Teacher;
            loadDto.Subject = load.Subject;
            loadDto.Group = load.Group;
            loadDto.HousPlan = load.HousPlan;
            loadDto.HousActuality = load.HousActuality;
            loadDto.Type = load.Type;
            return loadDto;
        }

        public static Load Convert(LoadDto loadDto)
        {
            if (loadDto == null)
                return null;
            Load load = new Load();
            load.LoadId = loadDto.Id;
            load.Teacher = loadDto.Teacher;
            load.Subject = loadDto.Subject;
            load.Group = loadDto.Group;
            load.HousPlan = loadDto.HousPlan;
            load.HousActuality = loadDto.HousActuality;
            load.Type = loadDto.Type;
            return load;
        }

        public static IList<LoadDto> Convert(IList<Load> loads)
        {
            if (loads == null)
                return null;
            IList<LoadDto> loadDtos = new List<LoadDto>();
            foreach(var load in loads)
            {
                loadDtos.Add(Convert(load));
            }
            return loadDtos;
        }
    }
}
