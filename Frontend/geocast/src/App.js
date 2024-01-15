import React, { useState } from 'react';
import WeatherList from './components/Weather/WeatherList/WeatherList';
import WeatherFetcher from './components/Weather/WeatherFetcher/WeatherFetcher';

const App = () => {
  const [weatherData, setWeatherData] = useState([]);
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);

  return (
    <div>
      <h1>7-Day Weather Forecast</h1>
      <WeatherFetcher setWeatherData={setWeatherData} setIsLoading={setIsLoading} setError={setError} />
      {isLoading && <p>Loading...</p>}
      {error && <p>{error}</p>}
      <WeatherList weatherData={weatherData} />
    </div>
  );
}

export default App;
