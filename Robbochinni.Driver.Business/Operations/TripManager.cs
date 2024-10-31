using Robbochinni.Driver.Mag.Abstracions;
using Robbochinni.Driver.Mag.Edition;
using Robbochinni.Driver.Mag.Enums;
using Robbochinni.Driver.Mag.Input;
using Robbochinni.Driver.Mag.Insertion;
using Robbochinni.Driver.Mag.Output;
using Robbochinni.Driver.Mag.Statics;
using Robbochinni.Driver.Mag.ValueObjects;

namespace Robbochinni.Driver.Business.Operations
{
    public class TripManager : Manager
    {
        private readonly ICommand<AddTrip> _tripCommand;
        private readonly IQuery<TripByState, TripInfo> _tripByStateQuery;
        private readonly IQuery<TripByCode, TripInfo> _tripByCodeQuery;
        private readonly IQuery<TripByClient, TripInfo> _tripByClientQuery;


        public TripManager(ICommand<AddTrip> tripCommand,
                           ResultBuilder resultBuilder,
                           IQuery<TripByState, TripInfo> tripByStateQuery,
                           IQuery<TripByCode, TripInfo> tripByCodeQuery,
                           IQuery<TripByClient, TripInfo> tripByClientQuery) : base(resultBuilder)
        {
            _tripCommand = tripCommand;
            _tripByStateQuery = tripByStateQuery;
            _tripByCodeQuery = tripByCodeQuery;
            _tripByClientQuery = tripByClientQuery;
        }

        public async Task<Result> Add(AddRequest request)
        {
            try
            {
                string code = "12345"; // RandomGenerator.Code;
                Guid tripId = await _tripCommand.Insert(new AddTrip(request.Pickup,
                                                                    request.DropOff,
                                                                    request.Client,
                                                                    Guid.Empty,
                                                                    TripState.New,
                                                                    DateTime.UtcNow,
                                                                    DateTime.UtcNow,
                                                                    DateTime.UtcNow,
                                                                    DateTime.UtcNow,
                                                                    new Secret(code).EncryptSHA256()));

                return _resultBuilder.Success!
                        .SetMessage("Entity Found")
                        .SetPayload(tripId);
            }
            catch (Exception ex)
            {
                return _resultBuilder.Error!.SetException(ex);
            }
        }

        public async Task<Result> EditTo(IEditTripModel state, Guid Id)
        {
            try
            {
                bool isExist = false;
                Guid tripId = Guid.Empty;
                switch (state.State)
                {
                    case TripState.ConfirmedByDriver:
                        _tripByStateQuery.SetInput(new TripByState(Id, TripState.New));
                        isExist = await _tripByStateQuery.IsExist();
                        break;
                    case TripState.Arrived:
                        var confirmed = (EditToArrived)state;
                        _tripByCodeQuery.SetInput(new TripByCode(Id, confirmed.Code));
                        isExist = await _tripByCodeQuery.IsExist();
                        break;
                    case TripState.Cancelled:
                        _tripByStateQuery.SetInput(new TripByState(Id, TripState.New));
                        isExist = await _tripByStateQuery.IsExist();
                        break;
                    case TripState.Finished:
                        _tripByStateQuery.SetInput(new TripByState(Id, TripState.Arrived));
                        isExist = await _tripByStateQuery.IsExist();
                        break;
                }

                if (isExist)
                {
                    tripId = await _tripCommand.Update(state, Id);
                    return _resultBuilder.Success!
                        .SetMessage("Entity Found")
                        .SetPayload(tripId);
                }
                else
                    return _resultBuilder.Error!
                        .SetMessage("Cannot Update This")
                        .SetPayload(tripId);


            }
            catch (Exception ex)
            {
                return _resultBuilder.Error!.SetException(ex);
            }
        }

        public async Task<Result> GetAll(int type)
        {
            try
            {
                var status = (TripState)type;

                _tripByStateQuery.SetInput(new TripByState(Guid.Empty, status));
                var result = await _tripByStateQuery.GetMany();

                return _resultBuilder.Success!
                    .SetMessage("Data Returned")
                    .SetPayload(result);


            }
            catch (Exception ex)
            {
                return _resultBuilder.Error!.SetException(ex);
            }
        }

        public async Task<Result> GetByClient(int type, Guid clientId, bool isDriver)
        {
            try
            {
                var status = (TripState)type;

                _tripByClientQuery.SetInput(new TripByClient(clientId, status, isDriver));
                var result = await _tripByClientQuery.GetMany();

                return _resultBuilder.Success!
                    .SetMessage("Data Returned")
                    .SetPayload(result);


            }
            catch (Exception ex)
            {
                return _resultBuilder.Error!.SetException(ex);
            }
        }
    }
}
