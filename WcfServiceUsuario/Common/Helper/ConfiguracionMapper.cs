using AutoMapper;
using WcfServiceUsuario.Dtos;
using WcfServiceUsuario.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WcfServiceUsuario.Common.Helper
{
    /// <typeparam name="T2"></typeparam>
    public class ConfiguracionMapper<T, T2>
    {
        /// <summary>
        /// metodo para mapaer entidades
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T2 Convert(T obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<T, T2>();
            });
            IMapper iMapper = config.CreateMapper();
            return iMapper.Map<T, T2>(obj);
        }
        /// <summary>
        /// metodo para mapear listas
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static List<T2> ConvertList(List<T> obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<T, T2>().ReverseMap();
            });
            IMapper iMapper = config.CreateMapper();
            return iMapper.Map<List<T>, List<T2>>(obj);
        }
        public static IEnumerable<T2> ConvertColec(IEnumerable<T> obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<T, T2>().ReverseMap();
            });
            IMapper iMapper = config.CreateMapper();
            return iMapper.Map<IEnumerable<T>, IEnumerable<T2>>(obj);
            //return <IEnumerable<T>, IEnumerable<T2>>(obj);
        }
    }
}
