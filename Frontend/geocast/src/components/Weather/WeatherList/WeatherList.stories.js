import React from 'react';
import WeatherList from './WeatherList';
import WeatherCard from '../WeatherCard/WeatherCard';
import { FlexContainer } from './styled';

export default {
  title: 'Weather/WeatherList',
  component: WeatherList,
};

const mockWeatherData = [
    {
      number: 1,
      name: 'Monday',
      startTime: new Date().toString(),
      icon: 'https://via.placeholder.com/150',
      shortForecast: 'Sunny',
      temperature: 75,
      temperatureUnit: 'F',
      detailedForecast: 'A bright sunny day with a light breeze.'
    },
    {
      number: 2,
      name: 'Monday Night',
      startTime: new Date().toString(),
      icon: 'https://via.placeholder.com/150',
      shortForecast: 'Clear',
      temperature: 60,
      temperatureUnit: 'F',
      detailedForecast: 'Clear skies with a gentle breeze.'
    },
    {
      number: 3,
      name: 'Tuesday',
      startTime: new Date().toString(),
      icon: 'https://via.placeholder.com/150',
      shortForecast: 'Partly Cloudy',
      temperature: 68,
      temperatureUnit: 'F',
      detailedForecast: 'Partly cloudy skies with a chance of afternoon showers.'
    },
    {
      number: 4,
      name: 'Tuesday Night',
      startTime: new Date().toString(),
      icon: 'https://via.placeholder.com/150',
      shortForecast: 'Showers',
      temperature: 55,
      temperatureUnit: 'F',
      detailedForecast: 'Showers expected with thunderstorms possible.'
    },
    {
      number: 5,
      name: 'Wednesday',
      startTime: new Date().toString(),
      icon: 'https://via.placeholder.com/150',
      shortForecast: 'Rain',
      temperature: 50,
      temperatureUnit: 'F',
      detailedForecast: 'Rain throughout the day, with heavy downpours in the afternoon.'
    },
    {
      number: 6,
      name: 'Wednesday Night',
      startTime: new Date().toString(),
      icon: 'https://via.placeholder.com/150',
      shortForecast: 'Cloudy',
      temperature: 48,
      temperatureUnit: 'F',
      detailedForecast: 'Overcast skies with a chance of drizzle.'
    },
    {
      number: 7,
      name: 'Thursday',
      startTime: new Date().toString(),
      icon: 'https://via.placeholder.com/150',
      shortForecast: 'Partly Cloudy',
      temperature: 55,
      temperatureUnit: 'F',
      detailedForecast: 'Partly cloudy with a cool breeze.'
    },
    {
      number: 8,
      name: 'Thursday Night',
      startTime: new Date().toString(),
      icon: 'https://via.placeholder.com/150',
      shortForecast: 'Clear',
      temperature: 45,
      temperatureUnit: 'F',
      detailedForecast: 'Clear skies and chilly temperatures.'
    },
    {
      number: 9,
      name: 'Friday',
      startTime: new Date().toString(),
      icon: 'https://via.placeholder.com/150',
      shortForecast: 'Sunny',
      temperature: 62,
      temperatureUnit: 'F',
      detailedForecast: 'Sunny and pleasant weather.'
    },
    {
      number: 10,
      name: 'Friday Night',
      startTime: new Date().toString(),
      icon: 'https://via.placeholder.com/150',
      shortForecast: 'Clear',
      temperature: 50,
      temperatureUnit: 'F',
      detailedForecast: 'Clear skies with cool evening temperatures.'
    },
    {
      number: 11,
      name: 'Saturday',
      startTime: new Date().toString(),
      icon: 'https://via.placeholder.com/150',
      shortForecast: 'Partly Cloudy',
      temperature: 68,
      temperatureUnit: 'F',
      detailedForecast: 'Partly cloudy with a chance of showers in the afternoon.'
    },
    {
      number: 12,
      name: 'Saturday Night',
      startTime: new Date().toString(),
      icon: 'https://via.placeholder.com/150',
      shortForecast: 'Showers',
      temperature: 55,
      temperatureUnit: 'F',
      detailedForecast: 'Showers and thunderstorms possible overnight.'
    },
    {
      number: 13,
      name: 'Sunday',
      startTime: new Date().toString(),
      icon: 'https://via.placeholder.com/150',
      shortForecast: 'Rain',
      temperature: 48,
      temperatureUnit: 'F',
      detailedForecast: 'Rain throughout the day with gusty winds.'
    },
    {
      number: 14,
      name: 'Sunday Night',
      startTime: new Date().toString(),
      icon: 'https://via.placeholder.com/150',
      shortForecast: 'Cloudy',
      temperature: 45,
      temperatureUnit: 'F',
      detailedForecast: 'Overcast skies and cool temperatures.'
    }
  ];
  

const Template = (args) => <WeatherList {...args} />;

export const Default = Template.bind({});
Default.args = {
  weatherData: mockWeatherData,
};
