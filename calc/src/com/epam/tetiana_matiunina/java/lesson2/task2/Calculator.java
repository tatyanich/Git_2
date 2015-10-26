package com.epam.tetiana_matiunina.java.lesson2.task2;

import com.epam.tetiana_matiunina.java.lesson2.task2.operation.*;
import com.sun.corba.se.spi.orb.Operation;

import java.util.*;

/**
 * Created by Администратор on 21.10.2015.
 */
public class Calculator {
    private Map<String, OperationAbstract> mapOperation = new TreeMap<String, OperationAbstract>();

    public void addOperation(Additon additon) {
        mapOperation.put(additon.getName(), additon);
    }

    public void divideOperation(Division division) {
        mapOperation.put(division.getName(), division);
    }

    public void multiplyOperation(Multiplication multiplication) {

        mapOperation.put(multiplication.getName(), multiplication);
    }

    public void subtractOperation(Subtraction subtraction) {
        mapOperation.put(subtraction.getName(), subtraction);
    }

    public double calculate(String operatorName, double firstNumber, double secondNumber) {

        try {
            double result = mapOperation.get(operatorName).operate(firstNumber, secondNumber);
            return result;
        } catch (ArithmeticException e) {
            System.out.print(e.getMessage());
            return Double.NaN;
        }
    }
}




