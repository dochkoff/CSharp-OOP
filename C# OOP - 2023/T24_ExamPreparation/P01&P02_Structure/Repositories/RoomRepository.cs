using System;
using System.Collections.Generic;
using System.Linq;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;

namespace BookingApp.Repositories
{
    public class RoomRepository : IRepository<IRoom>
    {
        private readonly List<IRoom> rooms;

        public RoomRepository()
        {
            rooms = new List<IRoom>();
        }

        public void AddNew(IRoom room)
            => rooms.Add(room);

        public IRoom Select(string roomTypeName)
        => rooms.FirstOrDefault(r => r.GetType().Name == roomTypeName);

        public IReadOnlyCollection<IRoom> All()
            => rooms.AsReadOnly();
    }
}