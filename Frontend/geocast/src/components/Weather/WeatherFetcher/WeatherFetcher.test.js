import { render, fireEvent, waitFor } from '@testing-library/react';
import WeatherFetcher from './WeatherFetcher';
import * as weatherService from '../../../services/WeatherService/weatherService';

jest.mock('../../../services/weatherService/weatherService');

describe('WeatherFetcher', () => {
  it('fetches weather data on button click', async () => {
    const mockSetWeatherData = jest.fn();
    const mockSetIsLoading = jest.fn();
    const mockSetError = jest.fn();
    const mockResponse = { data: [{ properties: { periods: ['periods123'] } }] };

    weatherService.fetchWeather.mockResolvedValue(mockResponse);

    const { getByLabelText, getByText } = render(
      <WeatherFetcher
        setWeatherData={mockSetWeatherData}
        setIsLoading={mockSetIsLoading}
        setError={mockSetError}
      />
    );

    const addressInput = getByLabelText(/enter address/i);
    const searchButton = getByText(/search/i);

    fireEvent.change(addressInput, { target: { value: 'address123' } });
    fireEvent.click(searchButton);

    await waitFor(() => expect(mockSetIsLoading).toHaveBeenCalledWith(true));
    await waitFor(() => expect(weatherService.fetchWeather).toHaveBeenCalledWith('address123'));
    await waitFor(() => expect(mockSetWeatherData).toHaveBeenCalledWith(['periods123']));
    await waitFor(() => expect(mockSetIsLoading).toHaveBeenCalledWith(false));
  });
});
