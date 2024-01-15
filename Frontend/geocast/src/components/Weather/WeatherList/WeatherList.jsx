import React, { useState } from 'react';
import WeatherCard from '../WeatherCard/WeatherCard';
import LightModeIcon from '@mui/icons-material/LightMode';
import ModeNightIcon from '@mui/icons-material/ModeNight';
import { FlexContainer, ToggleIconStyle } from './styled';

const WeatherList = ({ weatherData }) => {
  const [showDay, setShowDay] = useState(true);

  const dayForecasts = weatherData.filter(forecast => 
    !forecast.name.includes('Night') && forecast.name !== 'Tonight'
  );
  const nightForecasts = weatherData.filter(forecast => 
    forecast.name.includes('Night')  || forecast.name === 'Tonight'
  );

  return (
    <div>
      <ToggleIconStyle onClick={() => setShowDay(!showDay)}>
        {showDay ? <ModeNightIcon /> : <LightModeIcon />}
      </ToggleIconStyle>
      <FlexContainer>
        {dayForecasts.map(forecast => <WeatherCard key={forecast.number} forecast={forecast} />)}
      </FlexContainer>
      <FlexContainer>
        {nightForecasts.map(forecast => <WeatherCard key={forecast.number} forecast={forecast} />)}
      </FlexContainer>
    </div>
  );
}

export default WeatherList;
