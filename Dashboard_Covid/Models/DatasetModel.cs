using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dashboard_Covid.Models
{
    public class DatasetModel
    {

            public int ItbId { get; set; }
            public string iso_code { get; set; }
            public string continent { get; set; }
            public string location { get; set; }
            public DateTime date { get; set; }
            public double total_cases { get; set; }
            public double new_cases { get; set; }
            public double new_cases_smoothed { get; set; }
            public double total_deaths { get; set; }
            public double new_deaths { get; set; }
            public double new_deaths_smoothed { get; set; }
            public double total_cases_per_million { get; set; }
            public double new_cases_per_million { get; set; }
            public double new_cases_smoothed_per_million { get; set; }
            public double total_deaths_per_million { get; set; }
            public double new_deaths_per_million { get; set; }
            public double new_deaths_smoothed_per_million { get; set; }
            public double reproduction_rate { get; set; }
            public double icu_patients { get; set; }
            public double icu_patients_per_million { get; set; }
            public double hosp_patients { get; set; }
            public double hosp_patients_per_million { get; set; }
            public double weekly_icu_admissions { get; set; }
            public double weekly_icu_admissions_per_million { get; set; }
            public double weekly_hosp_admissions { get; set; }
            public double weekly_hosp_admissions_per_million { get; set; }
            public double new_tests { get; set; }
            public double total_tests { get; set; }
            public double total_tests_per_thousand { get; set; }
            public double new_tests_per_thousand { get; set; }
            public double new_tests_smoothed { get; set; }
            public double new_tests_smoothed_per_thousand { get; set; }
            public double positive_rate { get; set; }
            public double tests_per_case { get; set; }
            public string tests_units { get; set; }
            public double total_vaccinations { get; set; }
            public double people_vaccinated { get; set; }
            public double people_fully_vaccinated { get; set; }
            public double new_vaccinations { get; set; }
            public double new_vaccinations_smoothed { get; set; }
            public double total_vaccinations_per_hundred { get; set; }
            public double people_vaccinated_per_hundred { get; set; }
            public double people_fully_vaccinated_per_hundred { get; set; }
            public double new_vaccinations_smoothed_per_million { get; set; }
            public double stringency_index { get; set; }
            public double population { get; set; }
            public double population_density { get; set; }
            public double median_age { get; set; }
            public double aged_65_older { get; set; }
            public double aged_70_older { get; set; }
            public double gdp_per_capita { get; set; }
            public double extreme_poverty { get; set; }
            public double cardiovasc_death_rate { get; set; }
            public double diabetes_prevalence { get; set; }
            public double female_smokers { get; set; }
            public double male_smokers { get; set; }
            public double handwashing_facilities { get; set; }
            public double hospital_beds_per_thousand { get; set; }
            public double life_expectancy { get; set; }
            public double human_development_index { get; set; }

    }
}