# All the goodies here

- [ ] there should be multiple visual "layers" (z-indexes). e.g. one for content, second for modal windows and third for overlay etc.
- [ ] there should not be any layout shifts. Space should be pre-reserved to not jump all over the place
- [ ] swipe actions use CSS - carousels
- [ ] really confidential parts of the app should be pre-rendered and not be accessible via webassembly
- [ ] app storages information in OPFS
- [ ] app synchronizes changes via a web worker in the background
- [ ] blazor components store state in a DI injected object. Local properties and fields are allowed for simple variables that do not need to sync with the state manager
- [ ] all components with the same DI injected object should be rerendered once new state is present
- [ ] components should support view transitions. There would be JS interop that triggers the transition and fires blazor callback afterwards (component render)
- [ ] whole app should use vertical slices architecture. modules should be separated.
- [ ] apps storage should be modular. e.g. offline, online, sync (the app should not care)
- [ ] authentication is handled via webauthn
- [ ] user should be able to choose the security level - e.g. lifetime of tokens, login interval
- [ ] account (and important) changes must be re-authenticated via webauthn no matter the circumstances
- [ ] app needs to sync over the network
- [ ] app uses events to handle changes - not direct object changes
- [ ] there should be a user story for every scenario the user can encounter
