import React, { Component } from 'react'
import { scaleBand, scaleLinear } from 'd3-scale'
import _ from 'lodash'

import Axes from './Axes'
import Bars from './Bars'

import '../../styles/css/Chart.css'

export default class Chart extends Component {
  constructor() {
    super()
    this.xScale = scaleBand()
    this.yScale = scaleLinear()
  }

  getCurrentStudentGrade = () => {
    return _.find(this.props.data, (d) => d.userId === this.props.currentStudent.userId).grade
  }

  render() {
    const margins = { top: 50, right: 20, bottom: 100, left: 60 };
    const svgDimensions = { width: 800, height: 500 };

    const maxValue = Math.max(...this.props.data.map(d => d.grade));
    
    const sortedData = _(this.props.data).sortBy((d) => d.grade).reverse().value()

    const xScale = this.xScale
      .padding(0.5)
      .domain(sortedData.map(d => d.grade))
      .range([margins.left, svgDimensions.width - margins.right])

    const yScale = this.yScale
      .domain([0, maxValue])
      .range([svgDimensions.height - margins.bottom, margins.top])

    return (
      <svg width={svgDimensions.width} height={svgDimensions.height}>
        <Axes
         scales        = {{ xScale, yScale }}
         margins       = {margins}
         svgDimensions = {svgDimensions}
       />

       <Bars
          scales              = {{ xScale, yScale }}
          margins             = {margins}
          data                = {sortedData}
          maxValue            = {maxValue}
          svgDimensions       = {svgDimensions}
          currentStudentGrade = {this.getCurrentStudentGrade()}
        />
      </svg>
    )
  }
}
