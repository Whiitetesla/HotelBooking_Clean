Feature: Create Booking Examples
	In order to create a hotel booking
	as a customer i want to know if the
	room is already booked.

Scenario Outline: Create Booking
	Given I have entered a <startDate> and <endDate> 
	And a room is already booked from '1/3/2018' to '1/4/2018'
	When I press create booking
	Then the result should be '<outcome>'

	Examples:
	| startDate | endDate | outcome |
	|'1/1/2018' |'1/2/2018' |true  |
	|'1/5/2018' |'1/6/2018' |true  |
	|'1/1/2018' |'1/5/2018' |false |
	|'1/1/2018' |'1/3/2018' |false |
	|'1/1/2018' |'1/4/2018' |false |
	|'1/3/2018' |'1/3/2018' |false |
	|'1/4/2018' |'1/4/2018' |false |
	|'1/3/2018' |'1/4/2018' |false |
	|'1/4/2018' |'1/3/2018' |false |
	|'1/4/2018' |'1/5/2018' |false |
	|'1/3/2018' |'1/5/2018' |false |