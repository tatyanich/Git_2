package com.epam.tetiana_matiunina.java.task2.lesson2.rule;

import com.epam.tetiana_matiunina.java.task2.lesson2.airplane.models.Airplane;

import java.lang.reflect.InvocationTargetException;

/**
 * Created by Администратор on 21.10.2015.
 */
public interface IRule {

    /**
     * @param plane object of plane
     * @return
     * @throws InvocationTargetException
     * @throws IllegalAccessException
     */
    public boolean compareBy(Airplane plane) throws InvocationTargetException, IllegalAccessException;

}
