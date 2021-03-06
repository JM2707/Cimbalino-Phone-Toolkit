﻿// ****************************************************************************
// <copyright file="LocationServiceExtensions.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>20-04-2013</date>
// <project>Cimbalino.Phone.Toolkit.Location</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using Windows.Devices.Geolocation;

namespace Cimbalino.Phone.Toolkit.Services
{
    internal static class LocationServiceExtensions
    {
        public static PositionAccuracy ToPositionAccuracy(this LocationServiceAccuracy accuracy)
        {
            switch (accuracy)
            {
                case LocationServiceAccuracy.Default:
                    return PositionAccuracy.Default;

                case LocationServiceAccuracy.High:
                    return PositionAccuracy.High;

                default:
                    throw new ArgumentOutOfRangeException("accuracy");
            }
        }

        public static LocationServiceAccuracy ToLocationServiceAccuracy(this PositionAccuracy positionAccuracy)
        {
            switch (positionAccuracy)
            {
                case PositionAccuracy.Default:
                    return LocationServiceAccuracy.Default;

                case PositionAccuracy.High:
                    return LocationServiceAccuracy.High;

                default:
                    throw new ArgumentOutOfRangeException("positionAccuracy");
            }
        }

        public static LocationServiceStatus ToLocationServiceStatus(this PositionStatus positionStatus)
        {
            switch (positionStatus)
            {
                case PositionStatus.Ready:
                    return LocationServiceStatus.Ready;

                case PositionStatus.Initializing:
                    return LocationServiceStatus.Initializing;

                case PositionStatus.NoData:
                    return LocationServiceStatus.NoData;

                case PositionStatus.Disabled:
                    return LocationServiceStatus.Disabled;

                case PositionStatus.NotInitialized:
                    return LocationServiceStatus.NotInitialized;

                case PositionStatus.NotAvailable:
                    return LocationServiceStatus.NotAvailable;

                default:
                    throw new ArgumentOutOfRangeException("positionStatus");
            }
        }

        public static LocationServicePosition ToLocationServicePosition(this Geocoordinate coordinate)
        {
            return new LocationServicePosition(
                coordinate.Timestamp,
                coordinate.Latitude,
                coordinate.Longitude,
                coordinate.Accuracy,
                coordinate.Altitude,
                coordinate.AltitudeAccuracy,
                coordinate.Heading,
                coordinate.Speed);
        }

        public static LocationServicePositionChangedEventArgs ToLocationServicePositionChangedEventArgs(this PositionChangedEventArgs eventArgs)
        {
            return new LocationServicePositionChangedEventArgs(eventArgs.Position.Coordinate.ToLocationServicePosition());
        }

        public static LocationServiceStatusChangedEventArgs ToLocationServiceStatusChangedEventArgs(this StatusChangedEventArgs eventArgs)
        {
            return new LocationServiceStatusChangedEventArgs(eventArgs.Status.ToLocationServiceStatus());
        }
    }
}