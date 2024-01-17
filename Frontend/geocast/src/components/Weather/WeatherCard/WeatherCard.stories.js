import React from 'react';
import WeatherCard from './WeatherCard'; // Adjust the import path as necessary
import { CardContentStyle, CardStyle } from './styled'; // Import any necessary styled components

export default {
  title: 'Weather/WeatherCard',
  component: WeatherCard,
};

const Template = (args) => <WeatherCard {...args} />;

export const SunnyDay = Template.bind({});
SunnyDay.args = {
  forecast: {
    startTime: new Date().toString(),
    icon: 'https://via.placeholder.com/150',
    shortForecast: 'Sunny',
    name: 'Monday',
    temperature: 75,
    temperatureUnit: 'F',
    detailedForecast: 'A bright sunny day with a light breeze.'
  }
};

export const CloudyDay = Template.bind({});
CloudyDay.args = {
  forecast: {
    startTime: new Date().toString(),
    icon: 'https://via.placeholder.com/150',
    shortForecast: 'Cloudy',
    name: 'Tuesday',
    temperature: 68,
    temperatureUnit: 'F',
    detailedForecast: 'Overcast skies with a chance of rain in the evening.'
  }
};
