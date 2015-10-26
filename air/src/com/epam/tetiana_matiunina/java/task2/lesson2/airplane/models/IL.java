package com.epam.tetiana_matiunina.java.task2.lesson2.airplane.models;

/**
 * Created by Администратор on 20.10.2015.
 */
public class IL extends Airplane implements MilitaryAirplane {

    @Override
    public boolean hasWeapons() {
        return true;
    }

    public IL(String airplaneName, double liftingCapacity, double flightDistance, int seatingCapacity) {
        super(airplaneName, liftingCapacity, flightDistance, seatingCapacity);
    }
}
