import React from 'react';
import { Typography, CardMedia, Divider} from '@mui/material';
import { CardContentStyle, CardStyle } from './styled';

const WeatherCard = ({ forecast }) =>{


const getDay = () => {
  let startTime = new Date(forecast.startTime);
  let day = startTime.getDate();
  let month = startTime.getMonth() + 1;
  return `${day}/${month}`;
}

  return (  
    <CardStyle>
      <CardMedia
        component="img"
        height="140"
        image={forecast.icon}
        alt={forecast.shortForecast}
      />
      <CardContentStyle>
        <Typography variant="h5">{forecast.name}</Typography>
        <Typography variant="h6" color="#219ebc">{getDay()}</Typography>
        <Typography variant="subtitle1">{forecast.shortForecast}</Typography>
        <Typography variant="h5" color="#fb8500">{`${forecast.temperature} ${forecast.temperatureUnit}`}</Typography>
        <Divider/>
        <div>
          <Typography variant="body2">{forecast.detailedForecast}</Typography>
        </div>
      </CardContentStyle>
    </CardStyle>
  );
}

export default WeatherCard;