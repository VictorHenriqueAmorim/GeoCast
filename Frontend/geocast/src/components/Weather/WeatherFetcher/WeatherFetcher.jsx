import { useState } from "react";
import { Button, TextField } from "@mui/material";
import { fetchWeather } from "../../../services/WeatherService/weatherService";
import { WeatherFetcherStyle } from "./styled";

const WeatherFetcher = ({ setWeatherData, setIsLoading, setError }) => {
  const [address, setAddress] = useState('');

  const handleAddressChange = (event) => {
    setAddress(event.target.value);
  };

  const handleFetchWeather = () => {
    setIsLoading(true);
    setError(null);

    fetchWeather(address)
      .then(response => {
        setWeatherData(response.data[0].properties.periods);
        setIsLoading(false);
      })
      .catch(err => {
        setError(err.response.data);
        setIsLoading(false);
      });
  };

  return (
    <WeatherFetcherStyle>
      <TextField
        label="Enter Address"
        variant="outlined"
        value={address}
        onChange={handleAddressChange}
      />
      <Button variant="contained" color="primary" onClick={handleFetchWeather}>
        Search
      </Button>
    </WeatherFetcherStyle>
  );
}

export default WeatherFetcher;
