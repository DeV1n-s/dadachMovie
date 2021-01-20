const middleware = {}

middleware['myMiddleware'] = require('../middleware/myMiddleware.js')
middleware['myMiddleware'] = middleware['myMiddleware'].default || middleware['myMiddleware']

export default middleware
