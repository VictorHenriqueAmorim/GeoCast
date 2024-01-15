import axios from 'axios';

export const fetchWeather = (address) => {
  return axios.get(`https://localhost:44324/api/Weather/weather?address=${address}`);
};