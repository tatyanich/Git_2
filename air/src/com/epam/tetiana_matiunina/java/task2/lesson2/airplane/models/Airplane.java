package com.epam.tetiana_matiunina.java.task2.lesson2.airplane.models;

/**
 * Created by Tetiana Matiunina on 21.10.2015.
 */
public class Airplane {

    private String airplaneName;

    private double liftingCapacity;
    private double flightDistance;
    private double seatingCapacity;

    public Airplane(String airplaneName, double liftingCapacity, double flightDistance, int seatingCapacity) {
        this.airplaneName = airplaneName;
        this.liftingCapacity = liftingCapacity;
        this.flightDistance = flightDistance;
        this.seatingCapacity = seatingCapacity;
    }

    public String getName() {
        return airplaneName;
    }

    public double getFlightDistance() {
        return flightDistance;
    }

    public double getLiftingCapacity() {
        return liftingCapacity;
    }

    public double getRoominess() {
        return seatingCapacity;
    }
}


