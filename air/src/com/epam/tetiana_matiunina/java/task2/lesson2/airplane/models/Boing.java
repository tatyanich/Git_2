package com.epam.tetiana_matiunina.java.task2.lesson2.airplane.models;

/**
 * Created by Администратор on 21.10.2015.
 */
public class Boing extends Airplane implements CivilianAirplane {


    @Override
    public boolean hasStuards() {
        return true;
    }

    public Boing(String airplaneName, double liftingCapacity, double flightDistance, int seatingCapacity) {
        super(airplaneName, liftingCapacity, flightDistance, seatingCapacity);
    }


}
