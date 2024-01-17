import React  from 'react';
import WeatherCard from '../WeatherCard/WeatherCard';
import { FlexContainer } from './styled';

const WeatherList = ({ weatherData }) => {

  const dayForecasts = weatherData.filter(forecast => 
    !forecast.name.includes('Night') && forecast.name !== 'Tonight'
  );
  const nightForecasts = weatherData.filter(forecast => 
    forecast.name.includes('Night')  || forecast.name === 'Tonight'
  );

  return (
    <div>
      <FlexContainer id='dayCards'>
        {dayForecasts.map(forecast => <WeatherCard key={forecast.number + forecast.name} forecast={forecast} />)}
      </FlexContainer>
      <FlexContainer id='nightCards'>
        {nightForecasts.map(forecast => <WeatherCard key={forecast.number + forecast.name} forecast={forecast} />)}
      </FlexContainer>
    </div>
  );
}

export default WeatherList;
