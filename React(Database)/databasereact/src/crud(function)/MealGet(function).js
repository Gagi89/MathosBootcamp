import './css/meal.css';
import React from 'react';
import {useState} from 'react';

function MealGet() {

  const [meal, setMeal] = useState({element:[]});

  function Get() {

    const axios = require('axios');
  
    // axios.get('https://localhost:44345/api/meal')
    // .then(function (response) {
      
    //   console.log(response);
    // })
    // .catch(function (error) {
      
    //   console.log(error);
    // })
    // .then(function () {
    //   // always executed
    // });

    axios.get('https://localhost:44345/api/meal').then(response => {
      console.log(response);
      setMeal({element: response.data});
    });

  }
  
  return (
    <header>
        <button className="Button-meal" onClick={Get}>Get Meal</button>
        <table>
          <thead>
            <tr>
              <th>Name</th>
              <th>Calorie Number</th>
              <th>Date</th>
              <th>Description</th>
            </tr>
          </thead>
          <tbody>
            {meal.element.map((item) =>(
              <tr key={item.Id}>
                <td>{item.Name}</td>
                <td>{item.CalorieNumber}</td>
                <td>{item.Date}</td>
                <td>{item.Description}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </header>
  );
}

export default MealGet;
