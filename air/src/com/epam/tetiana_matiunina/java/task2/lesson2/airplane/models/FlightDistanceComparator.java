package com.epam.tetiana_matiunina.java.task2.lesson2.airplane.models;

import java.util.Comparator;

/**
 * Created by Администратор on 22.10.2015.
 */
public class FlightDistanceComparator implements Comparator<Airplane> {

    @Override
    public int compare(Airplane o1, Airplane o2) {
        return (int) (o1.getFlightDistance() - o2.getFlightDistance());
    }
}
