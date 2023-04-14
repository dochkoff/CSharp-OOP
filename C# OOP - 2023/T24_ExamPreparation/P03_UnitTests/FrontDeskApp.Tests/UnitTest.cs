using FrontDeskApp;
using NUnit.Framework;
using System;
using System.Linq;

namespace BookigApp.Tests
{
    public class Tests
    {
        Room room;
        Booking booking;
        Hotel hotel;

        [SetUp]
        public void Setup()
        {
            room = new(10, 10);
            booking = new(1, room, 2);
            hotel = new("Verea", 5);
        }

        [Test]
        public void RoomCtor()
        {
            Assert.AreEqual(10, room.BedCapacity);
            Assert.AreEqual(10, room.PricePerNight);
        }

        [Test]
        public void RoomProps()
        {
            Assert.Throws<ArgumentException>(() => room = new(0, 10));
            Assert.Throws<ArgumentException>(() => room = new(10, 0));
        }

        [Test]
        public void BookingCtor()
        {
            Assert.AreEqual(1, booking.BookingNumber);
            Assert.AreEqual(2, booking.ResidenceDuration);
            Assert.AreEqual(room, booking.Room);
        }

        [Test]
        public void HotelCtor()
        {
            Assert.AreEqual("Verea", hotel.FullName);
            Assert.AreEqual(5, hotel.Category);
            Assert.AreEqual(0, hotel.Rooms.Count);
            Assert.AreEqual(0, hotel.Bookings.Count);
        }

        [Test]
        public void HotelProps()
        {
            Assert.Throws<ArgumentNullException>(() => hotel = new(null, 5));
            Assert.Throws<ArgumentNullException>(() => hotel = new(" ", 5));
            Assert.Throws<ArgumentNullException>(() => hotel = new(string.Empty, 5));
            Assert.Throws<ArgumentException>(() => hotel = new("Verea", 0));
            Assert.Throws<ArgumentException>(() => hotel = new("Verea", 6));
            Assert.AreEqual(0, hotel.Turnover);
        }

        [Test]
        public void HotelAddRoom()
        {
            hotel.AddRoom(room);

            Assert.AreEqual(1, hotel.Rooms.Count);
            Assert.AreEqual(10, hotel.Rooms.First().BedCapacity);
            Assert.AreEqual(10, hotel.Rooms.First().PricePerNight);

        }

        [Test]
        public void HotelBookRoom()
        {
            hotel.AddRoom(room);
            hotel.BookRoom(3, 2, 1, 100);
            Assert.AreEqual(1, hotel.Bookings.Count);
            Assert.AreEqual(10, hotel.Turnover);
        }

        [Test]
        public void HotelCantBookRoom()
        {
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(0, 2, 1, 100));
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(3, -1, 1, 100));
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(3, 2, 0, 100));

            hotel.AddRoom(room);
            hotel.BookRoom(3, 2, 1, 5);
            Assert.AreEqual(0, hotel.Bookings.Count);
            Assert.AreEqual(0, hotel.Turnover);
        }
    }
}