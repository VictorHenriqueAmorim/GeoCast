import React  from 'react';
import { render, screen } from "@testing-library/react"
import WeatherList from "./WeatherList"

describe('WeatherList', () => {
    const mockWeatherData = [
        {
            startTime: new Date().toISOString(),
            icon: 'test',
            shortForecast: 'asdas',
            name: 'Today',
            temperature: 68,
            temperatureUnit: 'F',
            detailedForecast: 'asdasdasdasdasd'
        },
        {
            startTime: new Date().toISOString(),
            icon: 'test',
            shortForecast: 'asdas',
            name: 'Tonight',
            temperature: 68,
            temperatureUnit: 'F',
            detailedForecast: 'asdasdasdasdasd'
        }
    ]

    it('Render WeatherList', () => {
        render(<WeatherList weatherData={mockWeatherData}/>)

        const dayForecasts = screen.getAllByTestId('weather-card').filter(card =>
            !card.textContent.includes('Night') && !card.textContent.includes('Tonight')
        );
        const nightForecasts = screen.getAllByTestId('weather-card').filter(card =>
            card.textContent.includes('Night') || card.textContent.includes('Tonight')
        );
        
        expect(dayForecasts).toHaveLength(1);
        expect(nightForecasts).toHaveLength(1);
    })
})
