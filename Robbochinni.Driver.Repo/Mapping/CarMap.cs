using Mapster;
using Robbochinni.Driver.Mag.Insertion;
using Robbochinni.Driver.Mag.Output;
using Robbochinni.Driver.Repo.Entities;

namespace Robbochinni.Driver.Repo.Mapping
{
    public class CarMap : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AddCar, Car>()
                .Map(dest => dest.Name, src => src.Brand)
                .Map(dest => dest.Model, src => src.Class)
                .Map(dest => dest.Year, src => src.Year)
                .Map(dest => dest.Color, src => src.Color)
                .Map(dest => dest.Ref, src => src.Code)
                .Map(dest => dest.Number, src => src.Number)
                .Map(dest => dest.RideType, src => src.RideType)
                .Map(dest => dest.AvaialableIn, src => src.Location)
                .IgnoreNullValues(true);

            config.NewConfig<Car, CarInfo>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.DriverId, src => src.DriverId)
                .Map(dest => dest.DriverName, src => src.Driver!.FullName)
                .Map(dest => dest.Brand, src => src.Name)
                .Map(dest => dest.Class, src => src.Model)
                .Map(dest => dest.Year, src => src.Year)
                .Map(dest => dest.Color, src => src.Color)
                .Map(dest => dest.Code, src => src.Ref)
                .Map(dest => dest.Location, src => src.AvaialableIn)
                .Map(dest => dest.Number, src => src.Number);

            config.NewConfig<Mag.Insertion.Location, Entities.Location>()
                .Map(dest => dest.Name, src => src.LocationName)
                .Map(dest => dest.Longitude, src => src.Long)
                .Map(dest => dest.Latitude, src => src.Lat);

            config.NewConfig<Entities.Location, Mag.Insertion.Location>()
                .Map(dest => dest.LocationName, src => src.Name)
                .Map(dest => dest.Long, src => src.Longitude)
                .Map(dest => dest.Lat, src => src.Latitude);
        }
    }
}
