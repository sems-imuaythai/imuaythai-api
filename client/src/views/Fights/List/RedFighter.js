import React from 'react';
import Avatar from 'react-avatar';

export const RedFighter = props => {
    const { fighter, number, fight } = props;
    const fighterContent = !fighter ? (
        <h4 className="card-title">The winner of previous fight</h4>
    ) : (
        <div>
            <div className="row justify-content-between">
                {fight.winnerId === fighter.id && <h5 className="text-danger">The winner</h5>}
                <h4 className="card-title">{fighter.firstname + ' ' + fighter.surname}</h4>
            </div>
            <h6 className="card-subtitle mb-2 text-muted">
                {fighter.gymName || 'No gym'}, {fighter.countryName}
            </h6>
            <p className="card-text">
                <i className="fa fa-envelope" aria-hidden="true" />
                {' ' + fighter.email}
            </p>
        </div>
    );
    return (
        <div className="row ">
            <div className="col-md-2">
                <div className="bg-danger" style={{ color: 'white', width: '100%', height: '100%' }}>
                    <h2 className="text-center">{number}</h2>
                    <p className="text-center">Red corner</p>
                </div>
            </div>
            <div className="col-md-8 text-right align-self-center">{fighterContent}</div>
            <div className="col-md-2 align-self-center">
                <div className="row justify-content-start">
                    {fighter && <Avatar size={50} name={fighter.firstname + ' ' + fighter.surname} />}
                </div>
            </div>
        </div>
    );
};

export default RedFighter;
