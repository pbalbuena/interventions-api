class InterventionForm extends React.Component {

    state = {
        x
        date: '',
    };

    handleSubmit = e => {
        e.preventDefault();
        var date = this.date;
        if (!date) {
            return;
        }
        //this.props.onCommentSubmit({ date: date});
        //this.setState({ date: ''});
    };

    render() {
        
        return (
            <form onSubmit={this.handleSubmit}>
                <input type="date" value={this.state.date} class="form-control" />
                <input type="submit" class="form-control"/>
            </form>
        );
    }
}

class InterventionList extends React.Component {
    render() {
        var interventionList = this.props.
        return (
            <div>
                
            </div>
            );
    }
}