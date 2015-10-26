package com.epam.tetiana_matiunina.java.task2.lesson2.company;

import com.epam.tetiana_matiunina.java.task2.lesson2.airplane.models.Airplane;
import com.epam.tetiana_matiunina.java.task2.lesson2.airplane.models.FlightDistanceComparator;

import java.util.*;

/**
 * Created by Администратор on 21.10.2015.
 */
public abstract class AirCompany {
    private String companyName;

    private List<Airplane> airplainesList = new ArrayList<Airplane>();

    public AirCompany(String companyName) {
        this.companyName = companyName;
    }


    public List<Airplane> addAirplanes(ArrayList<Airplane> planes) {
//        for (Airplane plane : planes) {
//            airplainesList.add(plane);
//        }
        airplainesList.addAll(planes);
        return airplainesList;
    }

    public String getName() {
        return companyName;
    }

    public List<Airplane> getAirplanes() {
        return airplainesList;
    }

    public double calculateTotalCapacity() {
        double totalCapacity = 0.0;
        for (Airplane plane : airplainesList) {
            totalCapacity += plane.getLiftingCapacity();
        }
        return totalCapacity;
    }

    public double calculateTotalSeatingCapacity() {
        double totalRoominess = 0.0;
        for (Airplane plane : airplainesList) {
            totalRoominess += plane.getRoominess();
        }
        return totalRoominess;
    }

    public void sortPlaneByFlightDistance() {
        Collections.sort(airplainesList, new FlightDistanceComparator());
    }


}
